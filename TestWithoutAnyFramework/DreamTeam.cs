namespace TestWithoutAnyFramework
{
    public class DreamTeam
    {
        public string ReturnTsubasa(int? number)
        {
            if (number == 0)
            {
                return "Tsubasa Ozora";
            }
            else
            {
                return "Genzo Wakabayashi";
            }
        }
        public string ReturnTsubasa(int? number, string text)
        {
            return string.Empty;
        }
    }
}
