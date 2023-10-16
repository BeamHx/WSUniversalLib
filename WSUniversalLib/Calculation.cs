using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSUniversalLib
{
    public class Calculation
    {
        /// <summary>
        /// Метод должен принимать идентификатор типа продукции, идентификатор типа материала, количество необходимой продукции для производства, ширину продукции и длину продукции
        /// </summary>
        /// <param name="productType"></param>
        /// <param name="materialType"></param>
        /// <param name="count"></param>
        /// <param name="width"></param>
        /// <param name="length"></param>
        /// <returns>возвращать целое число - количество необходимого сырья с учетом возможного брака сырья.</returns>
        public static int GetQuantityForProduct(int productType, int materialType, int count, float width, float length)
        {
            if(productType > 3 || productType < 1)
            {
                return -1;
            }

            if (materialType > 2 || materialType < 1)
            {
                return -1;
            }

            float[] array = { 0f, 1.1f, 2.5f, 8.43f };
            float[] procArray = { 0f, 0.003f, 0.0012f };

            float finalCoutnWithoutProc = (count * (width * length) * array[productType]);
            int finalCount = (int)Math.Round(finalCoutnWithoutProc + (finalCoutnWithoutProc * procArray[materialType]));

            return finalCount;

        }
    }
}
