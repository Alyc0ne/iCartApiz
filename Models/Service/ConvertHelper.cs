using System;

namespace ServiceBase
{
    public static class ConvertHelper
    {
        #region To
        /// <summary>
        /// Convert with generic type (without specific default value).
        /// </summary>
        /// <typeparam name="T">Type name</typeparam>
        /// <param name="value">value that you want to convert</param>
        /// <param name="defaultValue">Default value.</param>
        /// <returns></returns>
        public static T To<T>(object value)
        {
            return To<T>(value, default(T));
        }

        /// <summary>
        /// Convert with generic type.
        /// </summary>
        /// <typeparam name="T">Type name</typeparam>
        /// <param name="value">value that you want to convert</param>
        /// <param name="defaultValue">Default value.</param>
        /// <returns></returns>
        public static T To<T>(object value, T defaultValue)
        {
            if (value == null || Convert.IsDBNull(value))
            {
                return default(T);
            }
            else
            {
                try
                {
                    return (T)value;
                }
                catch (Exception ex)
                {
                    return default(T);
                }
            }
        }
        #endregion

        #region ToDouble
        public static double ToDouble(object obj)
        {
            return ToDouble(obj, 0);
        }

        public static double ToDouble(object obj, double defaultValue)
        {
            try
            {
                if (System.Convert.IsDBNull(obj) || obj == null)
                {
                    return defaultValue;
                }
                else
                {
                    return Convert.ToDouble(obj);
                }
            }
            catch
            {
                return 0F;
            }
        }
        #endregion

        #region ToFloat
        public static float ToFloat(object obj)
        {
            return ToFloat(obj, 0);
        }

        public static float ToFloat(object obj, float defaultValue)
        {
            try
            {
                if (System.Convert.IsDBNull(obj) || obj == null)
                {
                    return defaultValue;
                }
                else
                {
                    return ((float)(Convert.ToDouble(obj)));
                }
            }
            catch
            {
                return 0F;
            }
        }
        #endregion

        #region ToInt
        public static int ToInt(object obj, int defaultValue)
        {
            try
            {
                if (System.Convert.IsDBNull(obj) || obj == null)
                {
                    return defaultValue;
                }
                else
                {

                    return Convert.ToInt32(obj);
                }
            }
            catch
            {
                return defaultValue;
            }
        }

        public static int ToInt(object obj)
        {
            return ToInt(obj, 0);
        }
        #endregion

        #region ToShort
        public static short ToShort(object obj, short defaultValue)
        {
            try
            {
                if (System.Convert.IsDBNull(obj) || obj == null)
                {
                    return defaultValue;
                }
                else
                {

                    return Convert.ToInt16(obj);
                }
            }
            catch
            {
                return defaultValue;
            }
        }

        public static short ToShort(object obj)
        {
            return ToShort(obj, 0);
        }
        #endregion

        #region ToLong
        public static long ToLong(object obj, long defaultValue)
        {
            try
            {
                if (System.Convert.IsDBNull(obj) || obj == null)
                {
                    return defaultValue;
                }
                else
                {

                    return Convert.ToInt64(obj);
                }
            }
            catch
            {
                return defaultValue;
            }
        }

        public static long ToLong(object obj)
        {
            return ToLong(obj, 0);
        }
        #endregion

        #region ToDecimal
        public static decimal ToDecimal(object obj, decimal defaultValue)
        {
            try
            {
                if (System.Convert.IsDBNull(obj) || obj == null)
                {
                    return defaultValue;
                }
                else
                {
                    return Convert.ToDecimal(obj);
                }
            }
            catch
            {
                return defaultValue;
            }
        }

        public static decimal ToDecimal(object obj)
        {
            return ToDecimal(obj, 0m);
        }
        #endregion

        #region ToString
        public static string ToString(object obj, string defaultValue)
        {
            if (System.Convert.IsDBNull(obj) || obj == null)
            {
                return defaultValue;
            }
            else
            {
                return obj.ToString();
            }
        }

        public static string ToString(object obj)
        {
            return ToString(obj, string.Empty);
        }
        #endregion

        #region ToDateTime
        public static DateTime ToDateTime(object obj, DateTime defaultValue)
        {
            if (System.Convert.IsDBNull(obj) || obj == null)
            {
                return defaultValue;
            }
            else
            {
                try
                {
                    return Convert.ToDateTime(obj);
                }
                catch (Exception ex)
                {
                    return defaultValue;
                }
            }
        }

        public static DateTime ToDateTime(object obj)
        {
            return ToDateTime(obj, DateTime.MinValue);
        }
        #endregion

        public static string ToDateTimeENG(object obj)
        {
            var Date = "";
            IFormatProvider cultureEN = new System.Globalization.CultureInfo("en-US", true); 
            Date = Convert.ToDateTime(obj).ToString("yyyy-MM-dd HH:mm:ss.fff", cultureEN);
            return Date;
        }

        #region ToBoolean
        public static bool ToBoolean(object obj)
        {
            return ToBoolean(obj, false);
        }

        public static bool ToBoolean(object obj, bool defaultValue)
        {
            try
            {
                if (System.Convert.IsDBNull(obj) || obj == null)
                {
                    return defaultValue;
                }
                else
                {
                    return Convert.ToBoolean(obj);
                }
            }
            catch
            {
                return defaultValue;
            }
        }
        #endregion

        #region ToByte
        public static byte ToByte(object obj)
        {
            return ToByte(obj, byte.MinValue);
        }

        public static byte ToByte(object obj, byte defaultValue)
        {
            try
            {
                if (System.Convert.IsDBNull(obj) || obj == null)
                {
                    return defaultValue;
                }
                else
                {
                    return Convert.ToByte(obj);
                }
            }
            catch
            {
                return defaultValue;
            }
        }
        #endregion

        #region Convert to ThaiEngBaht
        private static string ThreeDigitGroupToWords(long threeDigits)
        {

            string groupText = "";
            string[] _smallNumbers = new string[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            string[] _tens = new string[] { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            string[] _scaleNumbers = new string[] { "", "Thousand", "Million", "Billion" };
            long hundreds = threeDigits / 100;
            long tensUnits = threeDigits % 100;

            if (hundreds != 0)
            {

                groupText += _smallNumbers[hundreds] + " Hundred";

                if (tensUnits != 0)

                    groupText += " and ";

            }

            long tens = tensUnits / 10;
            long units = tensUnits % 10;

            if (tens >= 2)
            {

                groupText += _tens[tens];

                if (units != 0)

                    groupText += " " + _smallNumbers[units];

            }

            else if (tensUnits != 0)

                groupText += _smallNumbers[tensUnits];

            return groupText;

        }

        public static string NumberToWordsTh(string txtNumber)
        {

            string combined = "";
            long newnumber = 0;
            int MAX_DIGIT_ARRAY_TH = 6;

            string[] _smallNumbersTh = new string[] { "ศูนย์", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า" };
            string[] _scaleNumbersTh = new string[] { "", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน" };

            long number = 0;
            number = Convert.ToInt64(txtNumber);

            if (number == 0)
                return _smallNumbersTh[0];

            long[] digitGroups = new long[MAX_DIGIT_ARRAY_TH];
            long positive = Math.Abs(number);
            if (positive > 999999)
            {
                newnumber = positive / 1000000;
                positive = positive % 1000000;
            }

            for (int i = 0; i < MAX_DIGIT_ARRAY_TH; i++)
            {
                digitGroups[i] = positive % 10;
                positive /= 10;
            }

            string[] groupText = new string[MAX_DIGIT_ARRAY_TH];
            for (int i = 0; i < MAX_DIGIT_ARRAY_TH; i++)
            {
                if (digitGroups[i] > 0)
                {
                    if (digitGroups[i] == 1 && i == 0 && digitGroups[i + 1] > 0)
                    {
                        groupText[i] = "เอ็ด";
                    }
                    else if ((digitGroups[i] == 2 && i == 1))
                    {
                        groupText[i] = "ยี่";
                    }
                    else if (!(digitGroups[i] == 1 && i == 1))
                    {
                        groupText[i] = _smallNumbersTh[digitGroups[i]];
                    }
                }
            }

            combined += groupText[0];
            for (int i = 1; i < MAX_DIGIT_ARRAY_TH; i++)
            {
                if (digitGroups[i] != 0)
                {
                    string prefix = groupText[i] + _scaleNumbersTh[i];
                    combined = prefix + combined;
                }
            }

            if (newnumber > 0)
            {
                combined = NumberToWordsTh(ConvertHelper.ToString(newnumber)) + "ล้าน" + combined;
            }

            if (number < 0)
                combined = "ลบ " + combined;

            return combined;
        }

        public static string NumberToWords(string txtNumber)
        {
            int MAX_DIGIT_ARRAY = 4;
            string[] _smallNumbers = new string[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            string[] _tens = new string[] { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            string[] _scaleNumbers = new string[] { "", "Thousand", "Million", "Billion" };

            long number = 0;
            long decimalPoint = 0;
            if (txtNumber.IndexOf(".") > 0)
            {
                string[] separatePoint = txtNumber.Split('.');
                number = Convert.ToInt64(separatePoint[0]);
                if (separatePoint[1].Length > 2)
                {
                    decimalPoint = Convert.ToInt64(separatePoint[1].Substring(0, 2));
                }
                else if (separatePoint[1].Length == 2)
                {
                    decimalPoint = Convert.ToInt64(separatePoint[1]);
                }
                else
                {
                    decimalPoint = Convert.ToInt64((separatePoint[1] + '0'));
                }
            }
            else
            {
                number = Convert.ToInt64(txtNumber);
            }

            if (number == 0) return "( " + _smallNumbers[0].ToUpper() + " BAHT ONLY )";

            #region number section
            long[] digitGroups = new long[MAX_DIGIT_ARRAY];
            long positive = Math.Abs(number);
            for (int i = 0; i < MAX_DIGIT_ARRAY; i++)
            {
                digitGroups[i] = positive % 1000;
                positive /= 1000;
            }

            string[] groupText = new string[MAX_DIGIT_ARRAY];
            for (int i = 0; i < MAX_DIGIT_ARRAY; i++)
                groupText[i] = ThreeDigitGroupToWords(digitGroups[i]);
            string combined = groupText[0];

            bool appendAnd;
            appendAnd = (digitGroups[0] > 0) && (digitGroups[0] < 100);

            for (int i = 1; i < MAX_DIGIT_ARRAY; i++)
            {
                if (digitGroups[i] != 0)
                {
                    string prefix = groupText[i] + " " + _scaleNumbers[i];
                    if (combined.Length != 0)
                        prefix += appendAnd ? " and " : ", ";

                    appendAnd = false;
                    combined = prefix + combined;
                }
            }

            if (number < 0)
                combined = "Negative " + combined;
            #endregion

            #region decimal point section
            if (decimalPoint > 0)
            {
                long[] digitGroups2 = new long[MAX_DIGIT_ARRAY];
                long positive2 = Math.Abs(decimalPoint);
                for (int i = 0; i < MAX_DIGIT_ARRAY; i++)
                {
                    digitGroups2[i] = positive2 % 1000;
                    positive2 /= 1000;
                }

                string[] groupText2 = new string[MAX_DIGIT_ARRAY];
                for (int i = 0; i < MAX_DIGIT_ARRAY; i++)
                    groupText2[i] = ThreeDigitGroupToWords(digitGroups2[i]);
                string combined2 = groupText2[0];

                bool appendAnd2;
                appendAnd2 = (digitGroups2[0] > 0) && (digitGroups2[0] < 100);

                for (int i = 1; i < MAX_DIGIT_ARRAY; i++)
                {
                    if (digitGroups2[i] != 0)
                    {
                        string prefix2 = groupText2[i] + " " + _scaleNumbers[i];
                        if (combined2.Length != 0)
                            prefix2 += appendAnd2 ? " and " : ", ";

                        appendAnd2 = false;
                        combined2 = prefix2 + combined2;
                    }
                }
                combined = combined + " baht and " + combined2 + " satang";
            }
            else
            {
                combined = combined + " baht only";
            }
            #endregion

            return "( " + combined.ToUpper() + " )";

        }
        #endregion

        #region Convert to ThaiBath
        public static string ThaiBaht(string txt, string lang = "th-TH")
        {
            string txtNumber = "";
            if (lang == "en-US")
            {
                txtNumber = NumberToWords(txt);
            }
            else
            {
                long number = 0;
                long decimalPoint = 0;

                if (txt.IndexOf(".") > 0)
                {
                    //splite number by decimal point
                    //and set first number only
                    string[] separateNumber = txt.Split('.');
                    number = Convert.ToInt64(separateNumber[0]);

                    //checking decimal point
                    //by case more than 2 point substring 2 point
                    if (separateNumber[1].Length > 2)
                    {
                        decimalPoint = Convert.ToInt64(separateNumber[1].Substring(0, 2));
                    }
                    else if (separateNumber[1].Length == 2)
                    {
                        decimalPoint = Convert.ToInt64(separateNumber[1]);
                    }
                    else
                    {
                        decimalPoint = Convert.ToInt64((separateNumber[1] + '0'));
                    }

                    string n = NumberToWordsTh(number.ToString());
                    string decimalTxt = NumberToWordsTh(decimalPoint.ToString());
                    txtNumber = "( " + n + "บาท" + (decimalPoint > 0 ? decimalTxt + "สตางค์" : "ถ้วน") + " )";
                }
                else
                {
                    string n = NumberToWordsTh(txt.ToString());
                    txtNumber = "( " + n + "บาทถ้วน" + " )";
                }
            }

            return txtNumber;
        }
        #endregion
    }
}
