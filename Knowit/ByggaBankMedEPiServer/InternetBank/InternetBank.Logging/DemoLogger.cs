using System;

namespace InternetBank.Logging
{
    public class DemoLogger : IBankLogger
    {
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
