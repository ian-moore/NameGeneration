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
            return New(true);
        }

        public FullName New(bool useProbability)
        {
            var maleGender = ThreadSafeRandom.NextBool();

            if (maleGender)
            {
                return New(NameGender.Male, useProbability);
            }
            else
            {
                return New(NameGender.Female, useProbability);
            }
        }

        /// <summary>
        /// Get a random full name of a specific gender.
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        public FullName New(NameGender gender)
        {
            return New(gender, true);
        }

        public FullName New(NameGender gender, bool useProbability)
        {
            return new FullName()
            {
                First = NewFirst(gender, useProbability),
                Last = NewLast(useProbability),
                Gender = gender
            };
        }

        /// <summary>
        /// Get a random first name of a random gender.
        /// </summary>
        /// <returns></returns>
        public String NewFirst()
        {
            return NewFirst(true);
        }

        public String NewFirst(bool useProbability)
        {
            var maleGender = ThreadSafeRandom.NextBool();

            if (maleGender)
            {
                return NewFirst(NameGender.Male, useProbability);
            }
            else
            {
                return NewFirst(NameGender.Female, useProbability);
            }
        }

        /// <summary>
        /// Get a random first name of a specific gender.
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        public String NewFirst(NameGender gender)
        {
            return NewFirst(gender, true);
        }

        public String NewFirst(NameGender gender, bool useProbability)
        {
            List<NameRange> firstNameSet = (gender == NameGender.Male) ? Names.MaleNames : Names.FemaleNames;

            if (useProbability)
            {
                var firstNameMax = (gender == NameGender.Male) ? Names.MaleFirstNameMax : Names.FemaleFirstNameMax;
                var occurance = ThreadSafeRandom.Next(1, firstNameMax);

                return (from x in firstNameSet
                        where x.Min < occurance && x.Max > occurance
                        select x.Name).FirstOrDefault();
            }
            else
            {
                var index = ThreadSafeRandom.Next(0, firstNameSet.Count - 1);

                return firstNameSet[index].Name;
            }
            
        }

        /// <summary>
        /// Get a random last name.
        /// </summary>
        /// <returns></returns>
        public String NewLast()
        {
            return NewLast(true);
        }

        public String NewLast(bool useProbability)
        {
            if (useProbability)
            {
                var occurance = ThreadSafeRandom.Next(1, Names.LastNameMax);

                return (from x in Names.LastNames
                        where x.Min < occurance && x.Max > occurance
                        select x.Name).FirstOrDefault();
            }
            else
            {
                var index = ThreadSafeRandom.Next(0, Names.LastNames.Count - 1);

                return Names.LastNames[index].Name;
            }
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
