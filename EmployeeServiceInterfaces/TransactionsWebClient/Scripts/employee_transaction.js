$(document).ready(function () {
    $('#PersonTableContainer').jtable({
        title: 'Employees Info',
        actions: {
            listAction: '/Transaction/EmployeeList',
            createAction: '/Transaction/CreateEmployee'
            //updateAction: '/GettingStarted/UpdatePerson',
            //deleteAction: '/GettingStarted/DeletePerson'
        },
        fields: {
            employee_id: {

                title: 'Employee ID',
                width: '14%'
            },
            employee_name: {
                title: 'Employee Name',
                width: '20%'
            },
            employee_first_surname: {
                title: 'First Surname',
                width: '14%'
            },
            employee_second_surname: {
                title: 'Second Surname',
                width: '14%'
            },
            employee_email: {
                title: 'Email',
                width: '18%'
            },
            employee_username: {
                title: 'Usuario',
                width: '14%'
            },
            employee_salary: {
                title: 'Salario',
                width: '10%'
            }
        }
    });

    $('#PersonTableContainer').jtable("load");
});