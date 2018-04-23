app.controller('categoryCtrl', function ($scope, mainFactory, $timeout) {
    var uri = "/CategoryAPI/";
    var vm = this;
    vm.data = [];
    vm.edit_model = {};
    vm.delete_model = {};
    vm.insert_model = {};

    vm.getData = getData;
    vm.setEditModel = setEditModel;
    vm.updateData = updateData;
    vm.setDeleteModel = setDeleteModel;
    vm.deleteData = deleteData;
    vm.insertData = insertData;

    getData();

    function getData() {
        var getUrl = uri + "GetCategory";
        var data = {};
        mainFactory.doGet(data, getUrl).then(function (response) {
            console.log(response);
            vm.data = response.data;
            //if (!response.data.status) {
            //    return;
            //}
            //vm.data = response.data.data;
        });
    }

    function updateData() {
        var getUrl = uri + "UpdateCategory";
        var data = {
            "id": vm.edit_model.id,
            "name": vm.edit_model.name
        };

        console.log(data);
        mainFactory.doPost(data, getUrl).then(function (response) {
            console.log(response);
            $('#modalEdit').modal("hide");
            if (response.status == true) {
                alert("Cập nhật thành công");
                getData();
            }
            else {
                alert("Thất bại");
            }

        });
    }

    function deleteData() {
        var getUrl = uri + "DeleteCategory";
        var data = {
            "id": vm.delete_model.id,
            "name": vm.delete_model.name
        };

        console.log(data);
        mainFactory.doPost(data, getUrl).then(function (response) {
            console.log(response);
            $('#modalDelete').modal("hide");
            if (response.status == true) {
                alert("Xóa thành công");
                getData();
            }
            else {
                alert("Thất bại");
            }
        });
    };

    function setDeleteModel(item) {
        vm.delete_model = item;
    };

    function setEditModel(item) {
        vm.edit_model = item;
    };

    function insertData() {
        var getUrl = uri + "InsertCategory";
        var data = {
            "name": vm.insert_model.name
        };
        mainFactory.doPost(data, getUrl).then(function (response) {
            $('#modalInsert').modal("hide");
            getData();
            if (response.status == true) {
                alert("Insert thành công");
            }
            else {
                alert("Thất bại");
            }
        });
    }
});