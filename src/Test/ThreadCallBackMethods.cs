namespace Test;

internal class ThreadCallBackMethods
{
    void GetCallBackMethodValue(int result)
    {
        Console.WriteLine(result);
    }
    void CreateThread()
    {

        var callback = new CallBackMethods(GetCallBackMethodValue);

        var number = new Number(10, callback);

        Thread thread = new Thread(number.Calculate)
        {
            Name = "Test"
        };
        thread.Start();
    }

    delegate void CallBackMethods(int n);
    class Number
    {
        private int _value;
        private CallBackMethods callBackMethods;
        public Number(int n, CallBackMethods callBack)
        {
            _value = n;
            callBackMethods = callBack;
        }
        public void Calculate()
        {
            if (callBackMethods != null)
            {
                callBackMethods(_value);
            }
        }
    }

}
