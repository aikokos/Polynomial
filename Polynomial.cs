namespace Polynomial
{
    using System;

    public class Polynomial
    {
        private double[] coefficients;

        /// <summary>
        /// Creates new polynom by assigning coefficients
        /// </summary>
        /// <param name="coefficients">coefficients for polynom</param>
        public Polynomial(params double[] coefficients)
        {
            this.coefficients = coefficients;
        }

        /// <summary>
        /// Polynom order
        /// </summary>
        public int Order
        {
            get { return this.coefficients.Length; }
        }

        /// <summary>
        /// Getting or setting coefficients of polynom
        /// </summary>
        /// <param name="n">Coefficient index</param>
        /// <returns>Coefficient value</returns>
        public double this[int n]
        {
            get { return this.coefficients[n]; }
            set { this.coefficients[n] = value; }
        }

        /// <summary>
        /// Sum of polynomials
        /// </summary>
        public static Polynomial operator +(Polynomial first, Polynomial second)
        {
            int itemsCount = Math.Max(first.coefficients.Length, second.coefficients.Length);
            var result = new double[itemsCount];
            for (int i = 0; i < itemsCount; i++)
            {
                double a = 0;
                double b = 0;
                if (i < first.coefficients.Length)
                {
                    a = first[i];
                }

                if (i < second.coefficients.Length)
                {
                    b = second[i];
                }

                result[i] = a + b;
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// Difference between polynomials
        /// </summary>
        public static Polynomial operator -(Polynomial first, Polynomial second)
        {
            int itemsCount = Math.Max(first.coefficients.Length, second.coefficients.Length);
            var result = new double[itemsCount];
            for (int i = 0; i < itemsCount; i++)
            {
                double a = 0;
                double b = 0;
                if (i < first.coefficients.Length)
                {
                    a = first[i];
                }

                if (i < second.coefficients.Length)
                {
                    b = second[i];
                }

                result[i] = a - b;
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// Polynom multiplication
        /// </summary>
        public static Polynomial operator *(Polynomial first, Polynomial second)
        {
            int itemsCount = first.coefficients.Length + second.coefficients.Length - 1;
            var result = new double[itemsCount];
            for (int i = 0; i < first.coefficients.Length; i++)
            {
                for (int j = 0; j < second.coefficients.Length; j++)
                {
                    result[i + j] += first[i] * second[j];
                }
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// Overriding toString method for Polynomial.
        /// </summary>
        public override string ToString()
        {
            return string.Format("Coefficients are : " + string.Join(" ", this.coefficients));
        }

        /// <summary>
        /// Comparing two polynomials
        /// </summary>
        /// <param name="obj">Polynomial object</param>
        public override bool Equals(object obj)
        {
            Polynomial p = (Polynomial)obj;
            if (p != null)
            {
                if (p.Order == this.Order)
                {
                    for (int i = 0; i < this.Order; i++)
                    {
                        if (p[i] != this.coefficients[i])
                        {
                            return false;
                        }                         
                    }

                    return true;
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 20;
                for (int i = 0; i < this.coefficients.Length; i++)
                {
                    hash = (hash * 486187739) + this.coefficients[i].GetHashCode();
                }

                return hash;
            }
        }
    }
}
