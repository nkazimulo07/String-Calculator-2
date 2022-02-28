namespace String_Calculator_2.Interfaces
{
    public  interface IDelimiters
    {
        List<string> GetDelimiters(string numbers);
        List<string> GetMultipleDelimiters(string numbers);
    }
}
