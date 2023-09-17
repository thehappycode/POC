using System.Collections.Generic;

namespace RegularExpressions;
public class NextMatch
{
    const string VIETNAMESES_ALPHABET = "aAàÀảẢãÃáÁạẠăĂằẰẳẲẵẴắẮặẶâÂầẦẩẨẫẪấẤậẬbBcCdDđĐeEèÈẻẺẽẼéÉẹẸêÊềỀểỂễỄếẾệỆfFgGhHiIìÌỉỈĩĨíÍịỊjJkKlLmMnNoOòÒỏỎõÕóÓọỌôÔồỒổỔỗỖốỐộỘơƠờỜởỞỡỠớỚợỢpPqQrRsStTuUùÙủỦũŨúÚụỤưƯừỪửỬữỮứỨựỰvVwWxXyYỳỲỷỶỹỸýÝỵỴzZ";
    const string NUMBERS = "0123456789";
    const string NON_ALPHANUMERIC = @"@#%&!*:-_\/?.,";
    const string PATTERN = VIETNAMESES_ALPHABET + NUMBERS + NON_ALPHANUMERIC;

    public string FindNotMatch(string input)
    {
        var results = new List<string>();
        var match = Regex.Match(input, PATTERN);
        if (!match.Success)
            results.Add(match.Value);

        match = match.NextMatch();
        if (!match.Success)
            results.Add(match.Value);
    }
}
