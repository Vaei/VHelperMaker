﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VHelperMaker.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("VHelperMaker.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon AppIcon {
            get {
                object obj = ResourceManager.GetObject("AppIcon", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /** Print to log automatically while including the netmode. */
        ///	UFUNCTION(BlueprintCallable, Category = &quot;Helper&quot;, meta = (WorldContext = &quot;WorldContextObject&quot;, CallableWithoutWorldContext, DisplayName = &quot;Log&quot;))
        ///	static void K2_Log(UObject* WorldContextObject, const FString&amp; String);
        ///
        ///	/** Log a warning to the output log while including the netmode. */
        ///	UFUNCTION(BlueprintCallable, Category = &quot;Helper&quot;, meta = (WorldContext = &quot;WorldContextObject&quot;, CallableWithoutWorldContext, DisplayName = &quot;Log Warning&quot;)) [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string BlueprintLoggingHeaders {
            get {
                return ResourceManager.GetString("BlueprintLoggingHeaders", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///	UEnum* EnumPtr = FindObject&lt;UEnum&gt;((UObject*)ANY_PACKAGE, *EnumString, true);
        ///	if (EnumPtr)
        ///	{
        ///		int32 EnumIndex = EnumPtr-&gt;GetIndexByValue(EnumValue);
        ///		return (*EnumPtr-&gt;GetDisplayNameTextByIndex(EnumIndex).ToString());
        ///	}
        ///
        ///	return &quot;&quot;;
        ///}.
        /// </summary>
        internal static string EnumToString {
            get {
                return ResourceManager.GetString("EnumToString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///	if (InActor)
        ///	{
        ///		return EnumToString(&quot;ENetRole&quot;, (uint8)InActor-&gt;Role);
        ///	}
        ///
        ///	return &quot;NULL Actor&quot;;
        ///}.
        /// </summary>
        internal static string GetNetRole {
            get {
                return ResourceManager.GetString("GetNetRole", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /** @return the ENetRole of InActor as a string - actor is null checked */
        ///	static FString GetNetRole(AActor* InActor);
        ///	
        ///	/** @return the ENetRole of InActor as a string - actor is null checked */
        ///	static FString GetNetRole(const AActor* InActor);
        ///
        ///	/**
        ///	* @return the DisplayName of the enum (passed as EnumString) based on the EnumValue
        ///	* eg. EnumToString(&quot;EMyEnum&quot;, (uint8)EnumValue);
        ///	* @note : an empty string result implies the enum lookup failed (and you should double check the EnumString is c [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string HelperHeaders {
            get {
                return ResourceManager.GetString("HelperHeaders", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to #if defined(_MSC_VER)
        ///#define LOG_FUNC_NAME TEXT(__FUNCTION__)
        ///#else
        ///#define LOG_FUNC_NAME TEXT(__func__)
        ///#endif // _MSC_VER.
        /// </summary>
        internal static string LOG_FUNC_NAME {
            get {
                return ResourceManager.GetString("LOG_FUNC_NAME", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to #ifndef LOG_NETMODE_WORLD
        ///#define LOG_NETMODE_WORLD (((GEngine == nullptr) || (GetWorld() == nullptr)) ? TEXT(&quot;[Initialisation] &quot;) \
        ///            : (GEngine-&gt;GetNetMode(GetWorld()) == NM_Client) ? TEXT(&quot;[Client] &quot;) \
        ///            : (GEngine-&gt;GetNetMode(GetWorld()) == NM_ListenServer) ? TEXT(&quot;[Server] &quot;) \
        ///            : (GEngine-&gt;GetNetMode(GetWorld()) == NM_DedicatedServer) ? TEXT(&quot;[Server] &quot;) \
        ///            : (GEngine-&gt;GetNetMode(GetWorld()) == NM_Standalone) ? TEXT(&quot;[Standalone] &quot;) \
        ///            : TEXT [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string LOG_NETMODE_WORLD {
            get {
                return ResourceManager.GetString("LOG_NETMODE_WORLD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to #ifndef LOG_NETMODE_WORLD_STATIC
        ///#define LOG_NETMODE_WORLD_STATIC (((GEngine == nullptr) || (WorldContextObject-&gt;GetWorld() == nullptr)) ? TEXT(&quot;[Initialisation] &quot;) \
        ///            : (GEngine-&gt;GetNetMode(WorldContextObject-&gt;GetWorld()) == NM_Client) ? TEXT(&quot;[Client] &quot;) \
        ///            : (GEngine-&gt;GetNetMode(WorldContextObject-&gt;GetWorld()) == NM_ListenServer) ? TEXT(&quot;[Server] &quot;) \
        ///            : (GEngine-&gt;GetNetMode(WorldContextObject-&gt;GetWorld()) == NM_DedicatedServer) ? TEXT(&quot;[Server] &quot;) \
        ///            : (G [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string LOG_NETMODE_WORLD_STATIC {
            get {
                return ResourceManager.GetString("LOG_NETMODE_WORLD_STATIC", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to     const FString LogString = FString::Printf(TEXT(Format), ##__VA_ARGS__); \.
        /// </summary>
        internal static string LogString {
            get {
                return ResourceManager.GetString("LogString", resourceCulture);
            }
        }
    }
}
