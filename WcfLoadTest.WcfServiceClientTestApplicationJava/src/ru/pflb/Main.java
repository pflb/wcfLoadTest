package ru.pflb;
import system.io.Stream;
public class Main {

    public static void main(String[] args) {
	// write your code here
        {
            wcfloadtest.wcfserviceclient.ConfigLoader.Load();
            wcfloadtest.wcfserviceclient.ServiceBasicHttpClient serviceBasicHttpClient =
                    new wcfloadtest.wcfserviceclient.ServiceBasicHttpClient();
            int[] fileSizes = serviceBasicHttpClient.GetFileSizes();
            for(int index = 0; index < fileSizes.length; index++)
            {
                Stream file = serviceBasicHttpClient.GetFileBySize(fileSizes[index]);
                System.out.println(file.getLength());
            }
        }

        {
            wcfloadtest.wcfserviceclientpublic.ConfigLoader.Load();
            wcfloadtest.wcfserviceclientpublic.servicereferencebasichttp.ServiceBasicHttpClient serviceBasicHttpClient =
                    new wcfloadtest.wcfserviceclientpublic.servicereferencebasichttp.ServiceBasicHttpClient();
            int[] fileSizes = serviceBasicHttpClient.GetFileSizes();
            for(int index = 0; index < fileSizes.length; index++)
            {
                Stream file = serviceBasicHttpClient.GetFileBySize(fileSizes[index]);
                System.out.println(file.getLength());
            }
        }
    }
}
