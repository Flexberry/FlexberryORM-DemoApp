﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IIS.CDLIB
{
    using System;
    using System.Xml;
    using ICSSoft.STORMNET;
    
    
    // *** Start programmer edit section *** (Using statements)

    // *** End programmer edit section *** (Using statements)


    /// <summary>
    /// Publisher.
    /// </summary>
    // *** Start programmer edit section *** (Publisher CustomAttributes)

    // *** End programmer edit section *** (Publisher CustomAttributes)
    [AutoAltered()]
    [AccessType(ICSSoft.STORMNET.AccessType.none)]
    public class Publisher : ICSSoft.STORMNET.DataObject
    {
        
        private string fName;
        
        private IIS.CDLIB.Country fCountry;
        
        // *** Start programmer edit section *** (Publisher CustomMembers)

        // *** End programmer edit section *** (Publisher CustomMembers)

        
        /// <summary>
        /// Name.
        /// </summary>
        // *** Start programmer edit section *** (Publisher.Name CustomAttributes)

        // *** End programmer edit section *** (Publisher.Name CustomAttributes)
        [StrLen(255)]
        public virtual string Name
        {
            get
            {
                // *** Start programmer edit section *** (Publisher.Name Get start)

                // *** End programmer edit section *** (Publisher.Name Get start)
                string result = this.fName;
                // *** Start programmer edit section *** (Publisher.Name Get end)

                // *** End programmer edit section *** (Publisher.Name Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Publisher.Name Set start)

                // *** End programmer edit section *** (Publisher.Name Set start)
                this.fName = value;
                // *** Start programmer edit section *** (Publisher.Name Set end)

                // *** End programmer edit section *** (Publisher.Name Set end)
            }
        }
        
        /// <summary>
        /// Publisher.
        /// </summary>
        // *** Start programmer edit section *** (Publisher.Country CustomAttributes)

        // *** End programmer edit section *** (Publisher.Country CustomAttributes)
        [PropertyStorage(new string[] {
                "Country"})]
        [NotNull()]
        public virtual IIS.CDLIB.Country Country
        {
            get
            {
                // *** Start programmer edit section *** (Publisher.Country Get start)

                // *** End programmer edit section *** (Publisher.Country Get start)
                IIS.CDLIB.Country result = this.fCountry;
                // *** Start programmer edit section *** (Publisher.Country Get end)

                // *** End programmer edit section *** (Publisher.Country Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Publisher.Country Set start)

                // *** End programmer edit section *** (Publisher.Country Set start)
                this.fCountry = value;
                // *** Start programmer edit section *** (Publisher.Country Set end)

                // *** End programmer edit section *** (Publisher.Country Set end)
            }
        }
    }
}