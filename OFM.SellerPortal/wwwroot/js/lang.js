window.appCulture = {
    get: () => window.localStorage['AppLanguage'],
    set: (value) => window.localStorage['AppLanguage'] = value
};