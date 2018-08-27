using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

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
        public enum MorphemeOrigin {
            Greek,
            Latin,
            English
        }

        // Members.
        [DataMember]
        private readonly String morpheme;
        [DataMember]
        private List<String> meaning;
        [DataMember]
        private MorphemeOrigin origin;
        [DataMember]
        private MorphemeType morphemeType;

        // Accessors and Mutators
        [DataMember]
        public int ID { get; set; }
        public String Root {
            get {
                return morpheme;
            }
        }
        public List<String> Meaning {
            get {
                return meaning;
            }
        }
        public MorphemeOrigin Origin {
            get {
                return origin;
            }
        }
        public MorphemeType Type {
            get {
                return morphemeType;
            }
        }

        /// <summary>
        /// Default Constructor to initialize a new instance of the <see cref="T:etymology.Models.Morpheme"/> class.
        /// </summary>
        public Morpheme()
        {}


        /// <summary>
        /// Initializes a new instance of the <see cref="T:etymology.Models.Morpheme"/> class.
        /// </summary>
        public Morpheme(String Root, List<String> Meaning, MorphemeOrigin Origin)
        {
            if (!AssignType(Root.Trim()))
            {
                return;
            }

            morpheme = Root.Trim();
            meaning = Meaning.Select(s => s.Trim()).ToList();
            origin = Origin;
        }

        /// <summary>
        /// Assigns the Morpheme type.
        /// </summary>
        /// <returns><c>true</c>, if type was assigned, <c>false</c> otherwise.</returns>
        private bool AssignType(String Word)
        {
            if (Word != String.Empty)
            {
                if (Word.First() == '-')
                {
                    morphemeType = MorphemeType.Suffix;
                }
                else if (Word.Last() == '-')
                {
                    morphemeType = MorphemeType.Prefix;
                }
                else
                    morphemeType = MorphemeType.Root;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:etymology.Models.Morpheme"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:etymology.Models.Morpheme"/>.</returns>
        public override string ToString()
        {
            return morpheme;
        }

        /// <summary>
        /// Returns the onject instance serialized in json.
        /// </summary>
        /// <returns>The json of the Morpheme instance</returns>
        public string ToJson()
        {
            System.IO.MemoryStream stream1 = new System.IO.MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(this.GetType());

            ser.WriteObject(stream1, this);

            byte[] json = stream1.ToArray();
            stream1.Close();

            return System.Text.Encoding.UTF8.GetString(json, 0, json.Length);
        }
    }
}
