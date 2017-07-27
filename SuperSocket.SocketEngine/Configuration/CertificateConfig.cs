using SuperSocket.SocketBase.Config;
using System;
using System.Collections.Generic;
#if !NETSTANDARD2_0
using System.Configuration;
#endif
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SuperSocket.SocketEngine.Configuration
{
    /// <summary>
    /// Certificate configuration
    /// </summary>
#if !NETSTANDARD2_0
    public class CertificateConfig : ConfigurationElement, ICertificateConfig
    {
    #region ICertificateConfig Members

        /// <summary>
        /// Gets the certificate file path.
        /// </summary>
        [ConfigurationProperty("filePath", IsRequired = false)]
        public string FilePath
        {
            get
            {
                return this["filePath"] as string;
            }
        }

        /// <summary>
        /// Gets the password.
        /// </summary>
        [ConfigurationProperty("password", IsRequired = false)]
        public string Password
        {
            get
            {
                return this["password"] as string;
            }
        }

        /// <summary>
        /// Gets the the store where certificate locates.
        /// </summary>
        /// <value>
        /// The name of the store.
        /// </value>
        [ConfigurationProperty("storeName", IsRequired = false)]
        public string StoreName
        {
            get
            {
                return this["storeName"] as string;
            }
        }

        /// <summary>
        /// Gets the store location of the certificate.
        /// </summary>
        /// <value>
        /// The store location.
        /// </value>
        [ConfigurationProperty("storeLocation", IsRequired = false, DefaultValue = "CurrentUser")]
        public StoreLocation StoreLocation
        {
            get
            {
                return (StoreLocation)this["storeLocation"];
            }
        }

        /// <summary>
        /// Gets the thumbprint.
        /// </summary>
        [ConfigurationProperty("thumbprint", IsRequired = false)]
        public string Thumbprint
        {
            get
            {
                return this["thumbprint"] as string;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [client certificate required].
        /// </summary>
        /// <value>
        /// <c>true</c> if [client certificate required]; otherwise, <c>false</c>.
        /// </value>
        [ConfigurationProperty("clientCertificateRequired", IsRequired = false, DefaultValue = false)]
        public bool ClientCertificateRequired
        {
            get
            {
                return (bool)this["clientCertificateRequired"];
            }
        }

        /// <summary>
        /// Gets a value that will be used to instantiate the X509Certificate2 object in the CertificateManager
        /// </summary>
        [ConfigurationProperty("keyStorageFlags", IsRequired = false, DefaultValue = X509KeyStorageFlags.DefaultKeySet)]
        public X509KeyStorageFlags KeyStorageFlags
        {
            get
            {
                return (X509KeyStorageFlags)this["keyStorageFlags"];
            }
        }

    #endregion ICertificateConfig Members
    }
#else
    public class CertificateConfig : ICertificateConfig
    {
        #region ICertificateConfig Members

        /// <summary>
        /// Gets the certificate file path.
        /// </summary>  
        public string FilePath { get; set; }

        /// <summary>
        /// Gets the password.
        /// </summary>       
        public string Password { get; set; }
      
        /// <summary>
        /// Gets the the store where certificate locates.
        /// </summary>
        /// <value>
        /// The name of the store.
        /// </value>     
        public string StoreName { get; set; }

        /// <summary>
        /// Gets the store location of the certificate.
        /// </summary>
        /// <value>
        /// The store location.
        /// </value>      
        public StoreLocation StoreLocation { get; set; } = StoreLocation.CurrentUser;

        /// <summary>
        /// Gets the thumbprint.
        /// </summary>     
        public string Thumbprint { get; set; }


        /// <summary>
        /// Gets a value indicating whether [client certificate required].
        /// </summary>
        /// <value>
        /// <c>true</c> if [client certificate required]; otherwise, <c>false</c>.
        /// </value>
        public bool ClientCertificateRequired { get; set; }

        /// <summary>
        /// Gets a value that will be used to instantiate the X509Certificate2 object in the CertificateManager
        /// </summary>    
        public X509KeyStorageFlags KeyStorageFlags { get; set; } = X509KeyStorageFlags.DefaultKeySet;
       
        #endregion ICertificateConfig Members
    }
#endif
}
