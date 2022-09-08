var ViewModel = function () {
    var self = this;
    self.documents = ko.observableArray();
    self.equipments = ko.observableArray();
    self.financingVolumes = ko.observableArray();
    self.firms = ko.observableArray();
    self.furnitures = ko.observableArray();
    self.organizationFinancings = ko.observableArray();
    self.researchDirections = ko.observableArray();
    self.researchers = ko.observableArray();
    self.researches = ko.observableArray();
    self.stateResearches = ko.observableArray();
    self.error = ko.observable();

    var documentsUri = '/api/documents/';
    var equipmentsUri = '/api/equipments/';
    var financingVolumesUri = '/api/financingVolumes/';
    var firmsUri = '/api/firms/';
    var furnituresUri = '/api/furnitures/';
    var organizationFinancingsUri = '/api/organizationFinancings/';
    var researchDirectionsUri = '/api/researchDirections/';
    var researchersUri = '/api/researchers/';
    var researchesUri = '/api/researches/';
    var stateResearchesUri = '/api/stateResearches/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllDocuments() {
        ajaxHelper(documentsUri, 'GET').done(function (data) {
            self.documents(data);
        });
    }
    function getAllEquipments() {
        ajaxHelper(equipmentsUri, 'GET').done(function (data) {
            self.equipments(data);
        });
    } function getAllFinancingVolumes() {
        ajaxHelper(financingVolumesUri, 'GET').done(function (data) {
            self.financingVolumes(data);
        });
    } function getAllFirms() {
        ajaxHelper(firmsUri, 'GET').done(function (data) {
            self.firms(data);
        });
    } function getAllFurnitures() {
        ajaxHelper(furnituresUri, 'GET').done(function (data) {
            self.furnitures(data);
        });
    } function getAllOrganizationFinancings() {
        ajaxHelper(organizationFinancingsUri, 'GET').done(function (data) {
            self.organizationFinancings(data);
        });
    } function getAllResearchDirections() {
        ajaxHelper(researchDirectionsUri, 'GET').done(function (data) {
            self.researchDirections(data);
        });
    } function getAllResearchers() {
        ajaxHelper(researchersUri, 'GET').done(function (data) {
            self.researchers(data);
        });
    } function getAllResearches() {
        ajaxHelper(researchesUri, 'GET').done(function (data) {
            self.researches(data);
        });
    } function getAllStateResearches() {
        ajaxHelper(stateResearchesUri, 'GET').done(function (data) {
            self.stateResearches(data);
        });
    }
    // Fetch the initial data.
    getAllDocuments();
    getAllEquipments();
    getAllFinancingVolumes();
    getAllFirms();
    getAllFurnitures();
    getAllOrganizationFinancings();
    getAllResearchDirections();
    getAllResearchers();
    getAllResearches();
    getAllStateResearches();
};

ko.applyBindings(new ViewModel());