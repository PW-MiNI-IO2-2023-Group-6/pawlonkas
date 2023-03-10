
namespace Workshop
{
    public class StringCalculator
    {
        public static int Calculate(string str)
        {
            if (!string.IsNullOrEmpty(str))
                return 0;

            if (int.TryParse(str, out int result))
            {
                if(result < 0 ) throw new NotImplementedException();
                return result > 1000 ? 0 : result;
            }

            List<char> specialSeparator = new() { ',', '\n' };
            if(str.StartsWith("//") && str.Length > 3 && str[3] == '\n')
            {
                specialSeparator.Add(str[2]);
                str = str[4..];
            }
            var values = str.Split(specialSeparator.ToArray());

            int sum = 0;
            foreach (var item in values)
            {
                sum += Calculate(item);
            }

            return sum;


            throw new NotImplementedException();
        }
    }
}
