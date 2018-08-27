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
        public enum MorphemeOrigin {
            Greek,
            Latin,
            English
        }

        // Members.
        // Accessors and Mutators
        [DataMember]
        public int ID
        { get; set; }

        [DataMember]
        [JsonConverter(typeof(StringEnumConverter))]
        public MorphemeType RootType
        { get; set; }

        [DataMember]
        public String Root
        { get; set; }

        [NotMapped]
        public List<String> Meaning
        { get; set; }

        [DataMember]
        public string dbMeaning
        {
            get { return String.Join(',', Meaning); }
            set { Meaning = value.Split(',').ToList(); }
        }

        [DataMember]
        [JsonConverter(typeof(StringEnumConverter))]
        public MorphemeOrigin Origin
        { get; set; }

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
                    RootType = MorphemeType.Suffix;
                }
                else if (Word.Last() == '-')
                {
                    RootType = MorphemeType.Prefix;
                }
                else
                    RootType = MorphemeType.Root;
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
