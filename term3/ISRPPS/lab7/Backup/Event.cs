using System;

// делегат для события -ссылка на обработчики + сигнатура для обработчиков-
//(тип возврата + список параметров)
// 
delegate void KeyHandler(object source, KeyEventArgs arg);

//  параметры для обработчиков  
class KeyEventArgs : EventArgs 
{
	public char ch;
}

// класс события, связанного с нажатием клавиши на клавиатуре
class KeyEvent 
{
//  событие
	public event KeyHandler KeyPress;

//  генерация события, связанного с нажатием клавиши
	public void OnKeyPress(char key) 
	{
		KeyEventArgs k = new KeyEventArgs();
		if (KeyPress != null) 
		{
//  формирование аргумента для обработчиков
			k.ch = key;
			KeyPress(this,k);
		}
	}
}


//  класс, который принимает уведомление о нажатии клавиши (ожидает событие ) 
class ProcessKey 
{
//  обработчик события
	public void keyhandler (object source, KeyEventArgs arg) 
	{
		Console.WriteLine("Получено сообщение о нажати клавиши: " + arg.ch);
	}
}

//  класс, который принимает уведомление о нажатии клавиши (ожидает событие )
class CountKey 
{
	public int count = 0;
//  обработчик события
	public void keyhandler (object source, KeyEventArgs arg) 
	{
		count++;
	}
}

class KeyEventDemo 
{
	public static void Main() 
	{
		// создание объекта  класса события
		KeyEvent kevt = new KeyEvent();
		//  создание объекта класса, ожидающего событие 
		ProcessKey  pk = new ProcessKey ();
		//  создание объекта класса, ожидающего событие
		CountKey  ck = new CountKey();
		char ch;
		//  формирование списка обработчиков для события
		kevt.KeyPress += new KeyHandler(pk.keyhandler);
		kevt.KeyPress += new KeyHandler(ck.keyhandler);

		Console.WriteLine("Введите несколько символов." + "Для останова введите точку.");

		do 
		{
		//  нажатие клавиши
			ch = (char) Console.Read();
		//  генерация события
			kevt.OnKeyPress(ch);
		} while(ch!='.');
			Console.WriteLine("Было нажато " + ck.count +  "клавиш");
}
}






