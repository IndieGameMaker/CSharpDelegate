namespace DelegateApp;


// 델리게이트 (Delegate : 대리자) ==> Action / Event 문법 ==> 디자인 패턴 (옵저버 패턴, 이벤트 버스)
// 메서드(함수)를 저장하는 타입
// int a = 10;
// 델리게이트 sum = 함수;
// 델리게이트명 변수명 = 함수;
// public void Sum(int a, int b)

class Program
{
    //private delegate (저장할수 있는 함수의 형태);
    
    // 1. 델리게이트 선언
    private delegate void LoggerDelegate(string msg);
    
    // void ShowHp();
    // void DisplayMana();
    
    static void Main(string[] args)
    {
        // 2. 델리게이트 변수에 (메소드)할당
        LoggerDelegate log = Logger;
        // 3. 델리게이트 호출
        log("델리게이트 호출 1");
        log.Invoke("델리게이트 호출 2");
    }

    static void Logger(string msg)
    {
        Console.WriteLine("Hello Delegate");
    }
}