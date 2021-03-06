﻿using System;

public class Defines
{
    public enum Mode { View, Add, Update };

    internal class CriteriaDefines
    {
        internal static string criterium_id_stock = "id_stock";
        internal static string criterium_tank_name = "tank_name";
        internal static string criterium_location = "id_location";
        internal static string criterium_valid_from = "valid_from";
        internal static string criterium_valid_to = "valid_to";
        internal static string criterium_include_cancelled = "include_cancelled";
    }

    internal class SearchDefines
    {
        internal static string column_stock_number = "stock_number";
        internal static string column_tank_name = "tank_name";
        internal static string column_location = "id_location";
        internal static string column_location_name = "location_name";
        internal static string column_stock_capacity = "capacity";
        internal static string column_valid_from = "valid_from";
        internal static string column_valid_to = "valid_to";
        internal static string column_include_cancelled = "include_cancelled";
        internal static string column_status = "status";
        internal static string column_id_stock= "id_stock";
        internal static string column_id_tank = "id_tank";
        internal static string column_tank_quantity = "quantity";
    }

    internal class StockDefines
    {
        internal static string stock_id_stock = "id_stock";
        internal static string stock_number = "stock_number";
        internal static string stock_capacity = "capacity";
        internal static string stock_id_location = "id_location";
        internal static string stock_status = "status";
    }

    internal class TankDefines
    {
        internal static string tank_id_tank = "id_tank";
        internal static string tank_id_stock = "tank_id_stock";
        internal static string tank_name = "tank_name";
        internal static string tank_quantity = "quantity";
        internal static string tank_valid_from = "valid_from";
        internal static string tank_valid_to = "valid_to";
    }
    internal class LocationDefines
    {
        internal static string location_id_location = "id_location";
        internal static string location_name = "location_name";
    }
}
