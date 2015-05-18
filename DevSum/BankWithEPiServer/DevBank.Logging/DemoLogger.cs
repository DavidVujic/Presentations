using System;

namespace DevBank.Logging
{
    public class DemoLogger : IBankLogger
    {
		/// <summary>
		/// This one is for demo and presentation purposes only. Don't use it at home, folks.
		/// 
		/// You probably would want to have an implementation that uses log4net.
		/// </summary>
		/// <param name="data">data to log</param>
	    public void Add(object data)
	    {
			var serializer = new System.Xml.Serialization.XmlSerializer(data.GetType());

			var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\Demo.log");
		    
			var writer = new System.IO.StreamWriter(path, true);
		    
			serializer.Serialize(writer, data);

			writer.Close();
	    }
    }
}