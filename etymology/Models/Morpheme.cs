using System;
using System.Collections.Generic;
using System.Linq;

namespace etymology.Models
{
    /// <summary>
    /// Morpheme represents a class and structural representation of a root word.
    ///     "a meaningful morphological unit of a language that cannot be further divided (e.g. in, come, -ing, forming incoming )"
    /// </summary>
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
        private readonly String morpheme;
        private List<String> meaning;
        private MorphemeOrigin origin;
        private MorphemeType morphemeType;

        // Accessors and Mutators
        public int ID { get; set; }
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
        /// Initializes a new instance of the <see cref="T:etymology.Models.Morpheme"/> class.
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
            meaning = Meaning;
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
    }
}
