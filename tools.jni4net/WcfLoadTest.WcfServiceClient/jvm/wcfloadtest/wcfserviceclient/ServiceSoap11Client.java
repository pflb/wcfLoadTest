// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by jni4net. See http://jni4net.sourceforge.net/ 
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

package wcfloadtest.wcfserviceclient;

@net.sf.jni4net.attributes.ClrType
public class ServiceSoap11Client extends system.Object {
    
    //<generated-proxy>
    private static system.Type staticType;
    
    protected ServiceSoap11Client(net.sf.jni4net.inj.INJEnv __env, long __handle) {
            super(__env, __handle);
    }
    
    @net.sf.jni4net.attributes.ClrConstructor("()V")
    public ServiceSoap11Client() {
            super(((net.sf.jni4net.inj.INJEnv)(null)), 0);
        wcfloadtest.wcfserviceclient.ServiceSoap11Client.__ctorServiceSoap11Client0(this);
    }
    
    @net.sf.jni4net.attributes.ClrMethod("()V")
    private native static void __ctorServiceSoap11Client0(net.sf.jni4net.inj.IClrProxy thiz);
    
    @net.sf.jni4net.attributes.ClrMethod("()V")
    public native void Init();
    
    @net.sf.jni4net.attributes.ClrMethod("(LSystem/IO/Stream;)J")
    public native long LoadFileAndReturnFileSizeInBytes(system.io.Stream file);
    
    @net.sf.jni4net.attributes.ClrMethod("(I)LSystem/IO/Stream;")
    public native system.io.Stream GetFileBySize(int fileSize);
    
    @net.sf.jni4net.attributes.ClrMethod("()[I")
    public native int[] GetFileSizes();
    
    @net.sf.jni4net.attributes.ClrMethod("(I)I")
    public native int GetIntValue(int value);
    
    public static system.Type typeof() {
        return wcfloadtest.wcfserviceclient.ServiceSoap11Client.staticType;
    }
    
    private static void InitJNI(net.sf.jni4net.inj.INJEnv env, system.Type staticType) {
        wcfloadtest.wcfserviceclient.ServiceSoap11Client.staticType = staticType;
    }
    //</generated-proxy>
}