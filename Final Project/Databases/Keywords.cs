namespace Final_Project.TemplateClasses
{
    public class Keywords
    {
        private string[] keywords = { "Fight", "Flee", "Eat", "Keywords", "Settings" };

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


    }
}

