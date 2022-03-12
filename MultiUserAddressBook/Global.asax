<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        RegisterRoutes(System.Web.Routing.RouteTable.Routes);

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

    public static void RegisterRoutes(System.Web.Routing.RouteCollection routes)
    {
        routes.Ignore("{resource}.axd/{*pathInfo}");

        routes.MapPageRoute("AddressBookCountryList", "AdminPanel/Country/List", "~/AdminPanel/Country/CountryList.aspx");
        routes.MapPageRoute("AddressBookStateList", "AdminPanel/State/List", "~/AdminPanel/State/StateList.aspx");
        routes.MapPageRoute("AddressBookCityList", "AdminPanel/City/List", "~/AdminPanel/City/CityList.aspx");
        routes.MapPageRoute("AddressBookContactCategoryList", "AdminPanel/ContactCategory/List", "~/AdminPanel/ContactCategory/ContactCategoryList.aspx");
        routes.MapPageRoute("AddressBookContactList", "AdminPanel/Contact/List", "~/AdminPanel/Contact/ContactList.aspx");
        routes.MapPageRoute("AddressBookHome", "Home", "~/AdminPanel/Home.aspx");
        routes.MapPageRoute("AddressBookLogIn", "LogIn", "~/AdminPanel/loggin.aspx");
        routes.MapPageRoute("AddressBookSignUp", "SignUp", "~/AdminPanel/SignUp.aspx");

        routes.MapPageRoute("AddressBookCountryListHome", "AdminPanel/Country/List", "~/Content/Country/CountryList.aspx");
        routes.MapPageRoute("AddressBookStateListHome", "AdminPanel/State/List", "~/Content/State/StateList.aspx");
        routes.MapPageRoute("AddressBookCityListHome", "AdminPanel/City/List", "~/Content/City/CityList.aspx");
        routes.MapPageRoute("AddressBookContactCategoryListHome", "AdminPanel/ContactCategory/List", "~/Content/ContactCategory/ContactCategoryList.aspx");
        routes.MapPageRoute("AddressBookContactListHome", "AdminPanel/Contact/List", "~/Content/Contact/ContactList.aspx");

        routes.MapPageRoute("AddressBookCountryAdd", "AdminPanel/Country/{OperationName}", "~/AdminPanel/Country/CountryAddEdit.aspx");
        routes.MapPageRoute("AddressBookCountryEdit", "AdminPanel/Country/{OperationName}/{CountryID}", "~/AdminPanel/Country/CountryAddEdit.aspx");

        routes.MapPageRoute("AddressBookStateAdd", "AdminPanel/State/{OperationName}", "~/AdminPanel/State/StateAddEdit.aspx");
        routes.MapPageRoute("AddressBookStateEdit", "AdminPanel/State/{OperationName}/{StateID}", "~/AdminPanel/State/StateAddEdit.aspx");

        routes.MapPageRoute("AddressBookCityAdd", "AdminPanel/City/{OperationName}", "~/AdminPanel/City/CityAddEdit.aspx");
        routes.MapPageRoute("AddressBookCityEdit", "AdminPanel/City/{OperationName}/{CityID}", "~/AdminPanel/City/CityAddEdit.aspx");

        routes.MapPageRoute("AddressBookContactCategoryAdd", "AdminPanel/ContactCategory/{OperationName}", "~/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx");
        routes.MapPageRoute("AddressBookContactCategoryEdit", "AdminPanel/ContactCategory/{OperationName}/{ContactCategoryID}", "~/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx");

        routes.MapPageRoute("AddressBookContactAdd", "AdminPanel/Contact/{OperationName}", "~/AdminPanel/Contact/ContactAddEdit.aspx");
        routes.MapPageRoute("AddressBookContactEdit", "AdminPanel/Contact/{OperationName}/{ContactID}", "~/AdminPanel/Contact/ContactAddEdit.aspx");
    }

</script>
