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
        // Enumerations
        public enum MorphemeOrigin {
            Greek,
            Latin,
            English
        }

        // Members.
        private String morpheme;
        private IEnumerable<String> meaning;
        private MorphemeOrigin origin;

        // Accessors and Mutators
        public IEnumerable<String> Meaning {
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
        /// Initializes a new instance of the <see cref="T:etymology.Models.Morpheme"/> class.
        /// </summary>
        public Morpheme(String Root, IEnumerable<String> Meaning, MorphemeOrigin Origin)
        {
            morpheme = Root.Trim();
            meaning = Meaning.Select(s => s.Trim());
            origin = Origin;
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
