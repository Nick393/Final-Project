using System;

namespace Final_Project.TemplateClasses
{
    public class Keywords
    {
        private string[] keywords = {"Fight", "Flee", "Recover", "Heal", "Keywords", "Settings", "Exit", "Save", "Reset", "Yes", "Y", "No", "N"};


        //detects if the word is a keyword, should be used before detectKeyword
        public bool isKeyword(string input)
        {
            string upperInput = input.ToUpper();
            for (int i = 0; i < keywords.Length; i++)
            {
                string upperKeyword = keywords[i].ToUpper();
                if (upperInput == upperKeyword)
                {
                    return true;
                }
            }
            return false;
        }

        //detects what keyword was used
        public string detectKeyword(string input)
        {
            for (int i =0; i < keywords.Length; i++)
            {
                if (input.ToUpper() == keywords[i].ToUpper())
                {
                    return keywords[i];
                }
            }
            return null;
        }


    }
}

