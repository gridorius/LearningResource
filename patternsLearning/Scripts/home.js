
let app = new Vue({
    el: '.main',
    data: {
        briefDescriptions: [],
        list: [],
    },
    methods: {
        setBriefDescription(arr) {
            this.briefDescriptions = arr[0].art;
            this.list = arr[1];
        }
    }
});

fetch('/Home/BriefDescription').then(r => r.json()).then(app.setBriefDescription);
