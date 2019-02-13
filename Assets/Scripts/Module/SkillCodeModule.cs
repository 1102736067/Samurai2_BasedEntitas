using Game;
using UnityEngine;

namespace Module
{
    /// <summary>
    /// ���＼�ܱ��빦��ģ��
    /// </summary>
    public class SkillCodeModule     
    {
        public int GetCurrentSkillCode(SkillButton button, int currentCode)
        {
            int code = (int) button;
            if (currentCode < 0)
            {
                Debug.LogError("SkillCode����С��0");
            }
            else if (currentCode == 0)
            {
                currentCode = code;
            }
            else
            {
                currentCode = currentCode * 10 + code;
            }

            return currentCode;
        }

        public int GetSkillCode(string skillName,string prefix,string posfix)
        {
            string codeString = "";
            if (!string.IsNullOrEmpty(prefix))
            {
                codeString = skillName.Remove(0, prefix.Length);
            }

            if (!string.IsNullOrEmpty(posfix))
            {
                codeString = skillName.Remove(skillName.Length - posfix.Length, posfix.Length);
            }

            return ConvertStringToInt(codeString);
        }

        //ת��string���뵽int
        private int ConvertStringToInt(string codeString)
        {
            int[] codes = new int[codeString.Length];
            char[] chars = codeString.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == SkillButton.O.ToString()[0])
                {
                    codes[i] = (int) SkillButton.O;
                }
                else if (chars[i] == SkillButton.X.ToString()[0])
                {
                    codes[i] = (int)SkillButton.X;
                }
            }

            int code = 0;

            for (int i = 0; i < codes.Length; i++)
            {
                code += (int) (codes[i]*Mathf.Pow(10, codes.Length - 1 - i));
            }

            return code;
        }
        //ת��int���뵽string
        private string ConvertIntToString(int code)
        {
            string codeString = code.ToString();
            string[] codeStrings = new string[codeString.Length];

            for (int i = 0; i < codeStrings.Length; i++)
            {
                if (int.Parse(codeString[i].ToString()) == (int) SkillButton.O)
                {
                    codeStrings[i] = SkillButton.O.ToString();
                }
                else if(int.Parse(codeString[i].ToString()) == (int)SkillButton.X)
                {
                    codeStrings[i] = SkillButton.X.ToString();
                }
            }

            codeString = string.Join("", codeStrings);

            return codeString;
        }
    }

    public enum SkillButton
    {
        X = 1,
        O = 2
    }
}