let app = new Vue({
    el: '.main',
    data: {
        article: {
            art_name: '',
            art_description: '',
            art_motivation: '',
            art_pic: '',
            art_note: '',
            sample_part_gitref:'',
        },
        base_part: {
            base_part_name: '',
            base_part_description: '',
            base_part_info: '',
            base_part_pic:'',
        },
        sample_part: {
            sample_part_name: '',
            sample_part_description: '',
            sample_part_info: '',
            sample_part_pic: '',
            sample_part_code: '',
        },
        base_need: false,
        sample_need:false,
    },
    methods: {
        add() {
            let data = new FormData();
            data.append('article', this.article);
            data.append('base_part',this.base_part);
            data.append('sample_part',this.sample_part);
            data.append('base_need',this.base_need);
            data.append('sample_need', this.sample_need);
            fetch('urlAuthorize');
        }
    }
});