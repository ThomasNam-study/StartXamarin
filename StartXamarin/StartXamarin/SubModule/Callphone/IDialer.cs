using System;
using System.Collections.Generic;
using System.Text;

namespace StartXamarin.SubModule.Callphone
{
	public interface IDialer
	{
		bool Dial(string number);
	}
}
