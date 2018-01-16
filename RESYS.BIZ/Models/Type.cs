using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RESYS.BIZ.Models
{
    public enum SegmentType
    {
        NotApply = 1,
        FirstSegmentOutBound = 2,
        FirstSegmentInBound = 3,
    }

    public enum TripType
    {
        RoundTrip = 1,
        OneWay = 0,
        Bay_Nhieu_Chang = 3,
    }

    public enum WayType
    {
        OutBound = 0,
        InBound = 1,
    }
    public enum OrderStatus
    {
        Pending = 0,
        Active = 1,
        Complete =2,
        Finish = 3,
        Cancel = 99,
    }
    public enum OrderCustomType
    {
        Adult = 0,
        Child = 1,
        Infan = 2,
    }
    public enum EventType
    {
        OnClick = 1,
        OnDblClick = 2,
        OnMouseOver = 3,
    }

    public enum TransportType
    {
        None = 0,
        Flight = 1,
        Cruise = 2,
        Bus = 3,
    }

    public enum WarningType
    {
        New_Remark = 2,
        New_Cancellation = 3,
        PendingAmadeusBooking = 4,
        PendingHotelBooking = 5,
        PenddingInsuranceBooking = 6,
        InCompletePaymentBooking = 7,
        NoShowBooking = 8,
        OtherWarningBooking = 10,
    }

    public enum PackageType
    {
        Group = 1,
        Individual = 2,
    }

    public enum ActionType
    {
        View = 0,
        Insert = 1,
        Update = 2,
        Delete = 3,
    }

    public enum MessageType
    {
        SystemErrorMessage = 1,
        BusinessErrorMessage = 2,
        APIMessage = 3,
        WarningMessage = 4,
        FrontEndMessage = 5,
        OrtherMessage = 6,
        ErrorPage = 7,
    }

    public enum LocationType
    {
        Airport = 1,
        Country = 2,
        All = 3,
    }

    public enum SearchMode
    {
        Cache = 1,
        DataBase = 2,
        RealTime = 3,
    }
    public enum DiscountType
    {
        Percent = 1,
        Fix = 2,
    }
}