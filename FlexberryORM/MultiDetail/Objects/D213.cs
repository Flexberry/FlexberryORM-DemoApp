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
    /// D213.
    /// </summary>
    // *** Start programmer edit section *** (D213 CustomAttributes)

    // *** End programmer edit section *** (D213 CustomAttributes)
    [AutoAltered()]
    [ICSSoft.STORMNET.NotStored(false)]
    [AccessType(ICSSoft.STORMNET.AccessType.none)]
    public class D213 : IIS.CDLIB.D
    {
        
        private IIS.CDLIB.D21 fD21;
        
        // *** Start programmer edit section *** (D213 CustomMembers)

        // *** End programmer edit section *** (D213 CustomMembers)

        
        /// <summary>
        /// мастеровая ссылка на шапку IIS.CDLIB.D21.
        /// </summary>
        // *** Start programmer edit section *** (D213.D21 CustomAttributes)

        // *** End programmer edit section *** (D213.D21 CustomAttributes)
        [Agregator()]
        [NotNull()]
        [PropertyStorage(new string[] {
                "D21"})]
        public virtual IIS.CDLIB.D21 D21
        {
            get
            {
                // *** Start programmer edit section *** (D213.D21 Get start)

                // *** End programmer edit section *** (D213.D21 Get start)
                IIS.CDLIB.D21 result = this.fD21;
                // *** Start programmer edit section *** (D213.D21 Get end)

                // *** End programmer edit section *** (D213.D21 Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (D213.D21 Set start)

                // *** End programmer edit section *** (D213.D21 Set start)
                this.fD21 = value;
                // *** Start programmer edit section *** (D213.D21 Set end)

                // *** End programmer edit section *** (D213.D21 Set end)
            }
        }
    }
    
    /// <summary>
    /// Detail array of D213.
    /// </summary>
    // *** Start programmer edit section *** (DetailArrayDetailArrayOfD213 CustomAttributes)

    // *** End programmer edit section *** (DetailArrayDetailArrayOfD213 CustomAttributes)
    public class DetailArrayOfD213 : ICSSoft.STORMNET.DetailArray
    {
        
        // *** Start programmer edit section *** (IIS.CDLIB.DetailArrayOfD213 members)

        // *** End programmer edit section *** (IIS.CDLIB.DetailArrayOfD213 members)

        
        /// <summary>
        /// Construct detail array.
        /// </summary>
        /// <summary>
        /// Returns object with type D213 by index.
        /// </summary>
        /// <summary>
        /// Adds object with type D213.
        /// </summary>
        public DetailArrayOfD213(IIS.CDLIB.D21 fD21) : 
                base(typeof(D213), ((ICSSoft.STORMNET.DataObject)(fD21)))
        {
        }
        
        public IIS.CDLIB.D213 this[int index]
        {
            get
            {
                return ((IIS.CDLIB.D213)(this.ItemByIndex(index)));
            }
        }
        
        public virtual void Add(IIS.CDLIB.D213 dataobject)
        {
            this.AddObject(((ICSSoft.STORMNET.DataObject)(dataobject)));
        }
    }
}
