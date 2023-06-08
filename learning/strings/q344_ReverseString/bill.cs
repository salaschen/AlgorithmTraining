public class q344
{
    public void ReverseString(char[] s)
    {
        int lowPtr = 0;
        int hiPtr = s.Length - 1;
        char mem = '0';
        while (lowPtr < hiPtr)
        {
            mem = s[lowPtr];
            s[lowPtr] = s[hiPtr];
            s[hiPtr] = mem;
            lowPtr++;
            hiPtr--;
        }
    }
}
