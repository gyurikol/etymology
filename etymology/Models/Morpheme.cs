using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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
        [JsonConverter(typeof(StringEnumConverter))]
        private MorphemeOrigin origin;
        [DataMember]
        [JsonConverter(typeof(StringEnumConverter))]
        private MorphemeType morphemeType;

        // Accessors and Mutators
        [DataMember]
        public int ID { get; set; }
        public MorphemeType Type
        {
            get
            {
                return morphemeType;
            }
        }
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
        /// Initializes a new instance of the <see cref="T:etymology.Models.Morpheme"/> class.
        /// </summary>
        /// <param name="Root">Root word.</param>
        /// <param name="Meaning">Meaning of root.</param>
        /// <param name="Origin">Origin of root.</param>
        /// <param name="id">Identifier of specific Morpheme.</param>
        public Morpheme(String Root, List<String> Meaning, MorphemeOrigin Origin, int id)
        {
            if (!AssignType(Root.Trim()))
            {
                return;
            }

            ID = id;
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
