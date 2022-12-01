namespace Final_Project.TemplateClasses
{
    public class Keywords
    {
        private string[] keywords = { "Fight", "Flee", "Tame", "Kill", "Heal", "Keywords", "Exit", "Close", "Reset", "Yes", "Y", "No", "N", "Begin", "Start", "Load", "Help", "Save" };
        private const int startSystem = 5;

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

        public bool isSystemKeyword(string input)
        {
            string upperInput = input.ToUpper();
            for (int i = startSystem; i < keywords.Length; i++)
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
            for (int i = 0; i < keywords.Length; i++)
            {
                if (input.ToUpper() == keywords[i].ToUpper())
                {
                    return keywords[i];
                }
            }
            return null;
        }

        public string[] ListOfKeywords
        {
            get { return keywords; }
        }
    }
}

