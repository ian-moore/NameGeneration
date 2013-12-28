using System;
using System.Collections.Generic;
using System.Linq;

namespace NameGeneration
{
    public class NameGenerator
    {
        private NameCollections Names = new NameCollections();

        /// <summary>
        /// Get a random full name of a random gender.
        /// </summary>
        /// <returns>FullName instance containing a random first and last name.</returns>
        public FullName New()
        {
            var maleGender = ThreadSafeRandom.NextBool();

            if (maleGender)
            {
                return New(NameGender.Male);
            }
            else
            {
                return New(NameGender.Female);
            }
        }

        /// <summary>
        /// Get a random full name of a specific gender.
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        public FullName New(NameGender gender)
        {
            return new FullName()
            {
                First = NewFirst(gender),
                Last = NewLast(),
                Gender = gender
            };
        }

        /// <summary>
        /// Get a random first name of a random gender.
        /// </summary>
        /// <returns></returns>
        public String NewFirst()
        {
            var maleGender = ThreadSafeRandom.NextBool();

            if (maleGender)
            {
                return NewFirst(NameGender.Male);
            }
            else
            {
                return NewFirst(NameGender.Female);
            }
        }

        /// <summary>
        /// Get a random first name of a specific gender.
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        public String NewFirst(NameGender gender)
        {
            List<NameRange> firstNameSet = (gender == NameGender.Male) ? Names.MaleNames : Names.FemaleNames;
            var firstNameMax = (gender == NameGender.Male) ? Names.MaleFirstNameMax : Names.FemaleFirstNameMax;

            var firstNameIndex = ThreadSafeRandom.Next(1, firstNameMax);

            return (from x in firstNameSet
                    where x.Min < firstNameIndex && x.Max > firstNameIndex
                    select x.Name).FirstOrDefault();
        }

        /// <summary>
        /// Get a random last name.
        /// </summary>
        /// <returns></returns>
        public String NewLast()
        {
            var lastNameIndex = ThreadSafeRandom.Next(1, Names.LastNameMax);

            return (from x in Names.LastNames
                    where x.Min < lastNameIndex && x.Max > lastNameIndex
                    select x.Name).FirstOrDefault();
        }
    }

    /// <summary>
    /// Gender of a generated name.
    /// </summary>
    public enum NameGender
    {
        Male,
        Female
    }
}
