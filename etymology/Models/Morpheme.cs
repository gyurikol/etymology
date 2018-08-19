﻿using System;
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
        private String[] meaning;
        private MorphemeOrigin origin;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:etymology.Models.Morpheme"/> class.
        /// </summary>
        public Morpheme(String Root, String Meaning, MorphemeOrigin Origin)
        {
            
        }
    }
}