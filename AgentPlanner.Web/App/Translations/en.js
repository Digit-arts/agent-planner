var app = angular.module('agent_planner');
var en = {
    TOP_MENU: {
        ACCOUNT: {
            LABEL: 'Account',
            PROFILE: 'Profile',
            LOGOUT: 'Logout'
        },
        EMPLOYEES: {
            LABEL: 'Employees',
            ADD_NEW: 'Add new',
            VIEW_LIST: 'View all employees'
        },
        Clients: {
            LABEL: 'Clients',
            ADD_NEW: 'Add new',
            VIEW_LIST: 'View all clients'
        },
        Sites: {
            LABEL: 'Sites',
            ADD_NEW: 'Add new',
            VIEW_LIST: 'View all sites'
        }
    },
    Employee: {
        Columns: {
            EmployeeCode: 'Employee Code',
            FirstName: 'First Name',
            LastName: 'Last Name',
            Address: 'Address',
            Address2: 'Address2',
            ZipCode: 'Zip Code',
            City: 'City',
            PhoneNumber: 'Phone Number',
            EmailAddress: 'Email Address',
            DateOfBirth: 'Date Of Birth',
            Comments: 'Comments',
            IsActive: 'IsActive'
        }
    },
    Client: {
        Columns: {
            ClientCode: 'Client Code',
            Name: 'Name',
            Address: 'Address',
            Address2: 'Address2',
            ZipCode: 'Zip Code',
            City: 'City',
            ContactName: 'Contact Name',
            ContactPhoneNumber: 'Contact Phone Number',
            EmailAddress: 'Email Address',
            Comments: 'Comments',
            IsActive: 'Is Active',
            VatNumber: 'Vat Number',
            PaymentMethod: 'Payment Method',
            PaymentMethods: 'Payment Methods'
        }
    },
    Site: {
        Columns: {
            SiteCode: 'Site Code',
            Name: 'Name',
            ClientCode: 'Client Code',
            Address: 'Address',
            Address2: 'Address2',
            ZipCode: 'Zip Code',
            City: 'City',
            ContactName: 'Contact Name',
            ContactPhoneNumber: 'Contact Phone Number',
            EmailAddress: 'Email Address',
            Comments: 'Comments',
            IsActive: 'Is Active',
            SearchClient: 'Search Client'
        }
    },
    Assignment: {
        Columns: {
            SearchEmployee: 'Search Employee',
            TypeName: 'Type Name',
            StartDate: 'Start Date',
            EndDate: 'End Date',
            EmployeeEmail: 'Employee Email',
            AssignmentType:'Assignment Type',
            Duration:'Assignment Duration'
        }
    },
    Contract: {
        Columns: {
            StartDate: 'Start Date',
            EndDate: 'End Date',
            ContractType: 'Contract Type',
            BillingRate: 'Billing Rate',
            BillingFrequency: 'Billing Frequency',
            BillingFrequencies: 'Billing Frequencies',
            Comments: 'Comments',
            IsActive: 'IsActive',
            NightTimeRateIncrease: 'Night Time Rate Increase',
            SundayRateIncrease: 'Sunday Rate Increase',
            PublicHolidayRateIncrease: 'Public Holiday Rate Increase',
            AssignmentType: 'Assignment Type',
            AssignmentTypes: 'AssignmentTypes'
        },
        InfoMessages:
        {
            ContractDeleted: 'Contract deleted successfully',
            ContractDeleteConfirmation: 'Are you sure you want to delete this contract?'
        }
    }

};
app.config([
    '$translateProvider', function ($translateProvider) {
        $translateProvider.translations('en', en);
    }
]);