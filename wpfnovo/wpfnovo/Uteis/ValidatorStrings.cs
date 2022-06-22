namespace wpfnovo.Uteis
{
    public static class ValidatorStrings
    {
        public static bool Validator(string modelo, string ano, string cor)
        {
            if ((modelo == "") || (ano == "") || (cor == ""))
            {
                return false;
            }
            return true;
        }
    }
}
