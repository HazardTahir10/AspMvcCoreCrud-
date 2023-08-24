// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


/*function FillCities(lstCountryCtrl, lstCityId) {
    varlstCities = $("#" + lstCityId);
    lstCities.empty();


    var selectedCountry = lstCountryCtrl.options[lstCountryCtrl.selectedIndex].value;

    if (selectedCountry != null && selectedCountry != '') {
        $.getJSON("/home/GetCitiesByCountry", { countryId: selectedCountry }, function (cities) {
            if (cities != null && !JQuery.isEmptyObject(cities)) {
                $.each(cities, function (index, city) {
                    lstCities.append($('<option/',
                        {
                            value: city.value,
                            text: city.text
                        }));
                });
            };
        });
    }
    return;
}*/


function FillCities(lstCountryCtrl, lstCityId) {
    var lstCities = $("#" + lstCityId);
    lstCities.empty();

    var selectedCountry = lstCountryCtrl.options[lstCountryCtrl.selectedIndex].value;

    if (selectedCountry != null && selectedCountry != '') {
        $.getJSON("/Home/GetCitiesByCountry", { countryId: selectedCountry }, function (cities) {
            if (cities != null && !$.isEmptyObject(cities)) {
                $.each(cities, function (index, city) {
                    lstCities.append($('<option/>', {
                        value: city.value,
                        text: city.text
                    }));
                });
            }
        });
    }
}
