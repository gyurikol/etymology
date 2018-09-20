using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations.Schema;

namespace etymology.Models
{
    /// <summary>
    /// Morpheme represents a class and structural representation of a root word.
    ///     "a meaningful morphological unit of a language that cannot be further divided (e.g. in, come, -ing, forming incoming )"
    /// </summary>
    [DataContract]
    public class Morpheme
    {
        // Enumerations.
        /// <summary>
        /// Morpheme type.
        /// </summary>
        public enum MorphemeType
        {
            Root,
            Prefix,
            Suffix
        }
        /// <summary>
        /// Morpheme origin.
        /// </summary>
        public enum MorphemeOrigin
        {
            Greek,
            Latin,
            English
        }

        // Members.
        [NotMapped]
        private String _root;

        [NotMapped]
        private MorphemeType _type;

        // Accessors and Mutators
        [DataMember]
        public int ID
        { get; set; }

        [DataMember]
        [JsonConverter(typeof(StringEnumConverter))]
        public MorphemeType RootType
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        [DataMember]
        public String Root
        {
            get
            {
                return _root;
            }
            set
            {
                _root = value.Trim();
            }
        }

        [NotMapped]
        private List<String> _meaning
        { get; set; }

        [NotMapped]
        private List<String> _examples
        { get; set; }

        [DataMember]
        public String Meaning
        {
            get
            {
                return String.Join(',', _meaning);
            }
            set
            {
                _meaning = value.Split(',').Select(s => s.Trim()).ToList();
            }
        }

        [DataMember]
        public String Examples
        {
            get
            {
                return String.Join(',', _examples);
            }
            set
            {
                //_examples = FilterExamples(value.Split(',').Select(s => s.Trim()).ToList());
                _examples = value.Split(',').Select(s => s.Trim()).ToList();
            }
        }

        //[DataMember]
        //[JsonConverter(typeof(StringEnumConverter))]
        public MorphemeOrigin Origin
        { get; set; }



        // Functions.
        /// <summary>
        /// Filters the examples to remove redundancies and maintain used examples.
        /// </summary>
        /// <returns>List of examples.</returns>
        /// <param name="ExampleList">Example list.</param>
        public List<String> FilterExamples(List<String> ExampleList)
        {
            var tempList = new List<String>();

            foreach (String example in ExampleList)
            {
                if (!String.IsNullOrEmpty(example))
                {
                    if (_type == MorphemeType.Prefix)
                    {
                        if (example.Substring(0, example.Length - 1).Contains(_root))
                            tempList.Add(example);
                    }
                    else if (_type == MorphemeType.Suffix)
                    {
                        if (example.Substring(1).Contains(_root))
                            tempList.Add(example);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(_root))
                        {
                            Console.WriteLine("error");
                        }
                        if (example.Contains(_root))
                            tempList.Add(example);
                    }
                }
            }

            return tempList;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:etymology.Models.Morpheme"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:etymology.Models.Morpheme"/>.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Allows implicit conversion, casting and representation of Morhpeme as String.
        /// </summary>
        /// <returns>Morhpheme Object String</returns>
        /// <param name="m">Morpheme</param>
        public static implicit operator string(Morpheme m)
        {
            return m.ToString();
        }
    }
}
