$(document).ready(function () {
    $('#PersonTableContainer').jtable({
        title: 'Employees Info',
        actions: {
            listAction: '/GettingStarted/PersonList',
            createAction: '/GettingStarted/CreatePerson',
            updateAction: '/GettingStarted/UpdatePerson',
            deleteAction: '/GettingStarted/DeletePerson'
        },
        fields: {
            PersonId: {
                key: true,
                list: false
            },
            EmployeeID: {
                title: 'Employee ID',
                width: '14%'
            },
            Name: {
                title: 'Employee Name',
                width: '20%'
            },
            FSurname: {
                title: 'First Surname',
                width: '14%'
            },
            SSurname: {
                title: 'Second Surname',
                width: '14%'
            },
            Email: {
                title: 'Email',
                width: '18%'
            },

            Usuario: {
                title: 'Usuario',
                width: '14%'
            },

            Salario: {
                title: 'Salario',
                width: '10%'
            }
        }
    });

    /*$('#PersonTableContainer').jtable("load");*/
});