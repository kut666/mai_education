using System;

// делегат дл€ событи€ -ссылка на обработчики + сигнатура дл€ обработчиков-
//(тип возврата + список параметров)
// 
delegate void KeyHandler(object source, KeyEventArgs arg);

//  параметры дл€ обработчиков  
class KeyEventArgs
{
	public char ch;
}

// класс событи€, св€занного с нажатием клавиши на клавиатуре
class KeyEvent 
{
//  событие
	public event KeyHandler KeyPress;

//  генераци€ событи€, св€занного с нажатием клавиши
	public void OnKeyPress(char key) 
	{
		KeyEventArgs k = new KeyEventArgs();
		if (KeyPress != null) 
		{
//  формирование аргумента дл€ обработчиков
			k.ch = key;
			KeyPress(this, k);
		}
	}
}

abstract class ProcessKey
{
    protected ProcessKey successor;
    public void SetSuccessor(ProcessKey successor)
    {
        this.successor = successor;
    }

    public abstract void keyhandler(object source, KeyEventArgs arg);
}

class ConcreteProcessKey1 : ProcessKey
{
    public override void keyhandler(object source, KeyEventArgs arg)
    {
        if (arg.ch >= 'a' && arg.ch <= 'z')
        {
            Console.WriteLine("ѕолучено сообщение о нажатии клавиши: " + arg.ch);
            Console.WriteLine("{0} handled request {1}", this.GetType().Name, arg.ch);
        }
        else if (successor != null)
        {
           successor.keyhandler( source, arg);
        }
    }
}

class ConcreteProcessKey2 : ProcessKey
{
    public override void keyhandler(object source, KeyEventArgs arg)
    {
        if (arg.ch >= 'а' && arg.ch <= '€')
        {
            Console.WriteLine("ѕолучено сообщение о нажатии клавиши: " + arg.ch);
            Console.WriteLine("{0} handled request {1}",
            this.GetType().Name, arg.ch);
        }
        else if (successor != null)
        {
            successor.keyhandler(source, arg);
        }
    }
}

class ConcreteProcessKey3 : ProcessKey
{
    public override void keyhandler(object source, KeyEventArgs arg)
    {
        if (arg.ch >= '0' && arg.ch <= '9')
        {
            Console.WriteLine("ѕолучено сообщение о нажатии клавиши: " + arg.ch);
            Console.WriteLine("{0} handled request {1}",
            this.GetType().Name, arg.ch);
        }
        else if (successor != null)
        {
           successor.keyhandler(source, arg);
        }
    }
}

//  класс, который принимает уведомление о нажатии клавиши (ожидает событие )
class CountKey 
{
	public int count = 0;
//  обработчик событи€
	public void keyhandler (object source, KeyEventArgs arg) 
	{
		count++;
	}
}

class KeyEventDemo 
{
	public static void Main() 
	{
		// создание объекта  класса событи€
		KeyEvent kevt = new KeyEvent();

		//  создание объекта класса, ожидающего событие 
        ProcessKey h1 = new  ConcreteProcessKey1();
        ProcessKey h2 = new  ConcreteProcessKey2();
        ProcessKey h3 = new  ConcreteProcessKey3();
       
     h1.SetSuccessor(h2);
     h2.SetSuccessor(h3);

		//  создание объекта класса, ожидающего событие
	 CountKey  ck = new CountKey();

		char ch;

		//  формирование списка обработчиков дл€ событи€
		kevt.KeyPress += new KeyHandler(h1.keyhandler);
		kevt.KeyPress += new KeyHandler(ck.keyhandler);

		Console.WriteLine("¬ведите несколько символов." + "  ѕризнак конца - точка");

		do 
		{
		//  нажатие клавиши
			ch = (char) Console.Read();
		//  генераци€ событи€
			kevt.OnKeyPress(ch);
		} while(ch!='.');

		Console.WriteLine("Ѕыло нажато " + ck.count +  "  клавиш");
        Console.ReadKey();
    }
}






