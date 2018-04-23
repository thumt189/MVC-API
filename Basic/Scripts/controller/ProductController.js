app.controller('productCtrl', function ($scope, mainFactory, $timeout) {
    var uri = "/ProductAPI/";
    var vm = this;
    vm.data = [];
    vm.cat = [];
    vm.selected_cat = {};
    vm.edit_model = {};
    vm.delete_model = {};
    vm.insert_model = {};

    vm.getData = getData;
    vm.setEditModel = setEditModel;
    vm.updateData = updateData;
    vm.setDeleteModel = setDeleteModel;
    vm.deleteData = deleteData;
    vm.insertData = insertData;
    vm.selectCategory = selectCategory;

    getData();

    function getData() {
        var getUrl = uri + "GetProduct";
        var data = {};
        mainFactory.doGet(data, getUrl).then(function (response) {
            console.log(response);
            vm.data = response.data;
            vm.cat = response.other_data;
        });
    }

    function updateData() {
        var getUrl = uri + "UpdateProduct";
        var cat_id = $('#category_edit_id').val();
        var data = {
            "id": vm.edit_model.id,
            "cat_id": cat_id,
            "name": vm.edit_model.name,
            "price": vm.edit_model.price,
            "img": vm.edit_model.img,
        };

        console.log(data);
        mainFactory.doPost(data, getUrl).then(function (response) {
            console.log(response);
            if (response.status == true) {
                alert("Cập nhật thành công");
                getData();
            }
            else {
                alert("Thất bại");
            }
            $('#modalEdit').modal("hide");
        });
    }

    function deleteData() {
        var getUrl = uri + "DeleteProduct";
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
        console.log(item);
        var cat_id = item.cat_id.toString();
        $('#category_edit_id').select2("val", cat_id);
    };
    
    function insertData() {
        var getUrl = uri + "InsertProduct";
        var cat_id = $('#category_id').val();
        var data = {
            "name": vm.insert_model.name,
            "cat_id": cat_id,
            "price": vm.insert_model.price,
            "img": vm.insert_model.img + ".jpg"
        };
        console.log(data);
        mainFactory.doPost(data, getUrl).then(function (response) {
            if (response.status == true) {
                alert("Insert thành công");
                getData();
            }
            else {
                alert("Thất bại: " + response.message);
            }
            $('#modalInsert').modal("hide");
        });
    }

    function selectCategory(item) {
        debugger;
        vm.selected_cat = item;
        console.log(item);
    }
});