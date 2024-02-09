namespace TPVLib
{
    public interface ITPV
    {
        static ITPV CreateNewTPV()
        {
            return new RAMTPV();
        }
    }
}
