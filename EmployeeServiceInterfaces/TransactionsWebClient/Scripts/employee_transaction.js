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
                    width: '14%',
                    inputClass: 'validate[required]'
                },
                employee_name: {
                    title: 'Employee Name',
                    width: '20%',
                    inputClass: 'validate[required]'
                },
                employee_first_surname: {
                    title: 'First Surname',
                    width: '14%',
                    inputClass: 'validate[required]'
                },
                employee_second_surname: {
                    title: 'Second Surname',
                    width: '14%',
                    inputClass: 'validate[required]'
                },
                employee_email: {
                    title: 'Email',
                    width: '18%',
                    inputClass: 'validate[required]'
                },
                employee_username: {
                    title: 'Usuario',
                    width: '14%',
                    inputClass: 'validate[required]'
                 
                },
                employee_salary: {
                    title: 'Salario',
                    width: '10%',
                    defaultValue: 0,
                    inputClass: 'validate[required]'
                }
            },
            formCreated: function (event, data) {
                data.form.validationEngine();
            },
            //Validate form when it is being submitted
            formSubmitting: function (event, data) {
                return data.form.validationEngine('validate');
            },
            //Dispose validation logic when form is closed
            formClosed: function (event, data) {
                data.form.validationEngine('hide');
                data.form.validationEngine('detach');
            }

    });

    $('#PersonTableContainer').jtable("load");
});