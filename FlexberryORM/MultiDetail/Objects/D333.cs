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
    /// D333.
    /// </summary>
    // *** Start programmer edit section *** (D333 CustomAttributes)

    // *** End programmer edit section *** (D333 CustomAttributes)
    [AutoAltered()]
    [ICSSoft.STORMNET.NotStored(false)]
    [AccessType(ICSSoft.STORMNET.AccessType.none)]
    public class D333 : IIS.CDLIB.D
    {
        
        private IIS.CDLIB.D33 fD33;
        
        // *** Start programmer edit section *** (D333 CustomMembers)

        // *** End programmer edit section *** (D333 CustomMembers)

        
        /// <summary>
        /// мастеровая ссылка на шапку IIS.CDLIB.D33.
        /// </summary>
        // *** Start programmer edit section *** (D333.D33 CustomAttributes)

        // *** End programmer edit section *** (D333.D33 CustomAttributes)
        [Agregator()]
        [NotNull()]
        [PropertyStorage(new string[] {
                "D33"})]
        public virtual IIS.CDLIB.D33 D33
        {
            get
            {
                // *** Start programmer edit section *** (D333.D33 Get start)

                // *** End programmer edit section *** (D333.D33 Get start)
                IIS.CDLIB.D33 result = this.fD33;
                // *** Start programmer edit section *** (D333.D33 Get end)

                // *** End programmer edit section *** (D333.D33 Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (D333.D33 Set start)

                // *** End programmer edit section *** (D333.D33 Set start)
                this.fD33 = value;
                // *** Start programmer edit section *** (D333.D33 Set end)

                // *** End programmer edit section *** (D333.D33 Set end)
            }
        }
    }
    
    /// <summary>
    /// Detail array of D333.
    /// </summary>
    // *** Start programmer edit section *** (DetailArrayDetailArrayOfD333 CustomAttributes)

    // *** End programmer edit section *** (DetailArrayDetailArrayOfD333 CustomAttributes)
    public class DetailArrayOfD333 : ICSSoft.STORMNET.DetailArray
    {
        
        // *** Start programmer edit section *** (IIS.CDLIB.DetailArrayOfD333 members)

        // *** End programmer edit section *** (IIS.CDLIB.DetailArrayOfD333 members)

        
        /// <summary>
        /// Construct detail array.
        /// </summary>
        /// <summary>
        /// Returns object with type D333 by index.
        /// </summary>
        /// <summary>
        /// Adds object with type D333.
        /// </summary>
        public DetailArrayOfD333(IIS.CDLIB.D33 fD33) : 
                base(typeof(D333), ((ICSSoft.STORMNET.DataObject)(fD33)))
        {
        }
        
        public IIS.CDLIB.D333 this[int index]
        {
            get
            {
                return ((IIS.CDLIB.D333)(this.ItemByIndex(index)));
            }
        }
        
        public virtual void Add(IIS.CDLIB.D333 dataobject)
        {
            this.AddObject(((ICSSoft.STORMNET.DataObject)(dataobject)));
        }
    }
}