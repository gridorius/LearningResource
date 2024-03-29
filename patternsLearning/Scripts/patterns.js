﻿Vue.component('category', {
    template: `    
    <div>
            <h2 class='catergory' @click='selected = !selected;$root.showInfo = false' :title='description'>{{name}}</h2>
            <ul :class='{open:selected}'>
                <li class='pattern' v-for='art in article'><div :title='art.art_description' @click='$root.showArticle(art.art_id)'>{{art.art_name}}</div></li>
            </ul>
        </div>
    `,
    props: ['name', 'description','article'],
    data() {
        return {
            selected: false,
        }
    },
});

let app = new Vue({
    el: '.main',
    data: {
        showInfo: false,
        categories: [],
        info: '',
        article: false,
    },
    methods: {
        setCategories(obj) {
            this.info = obj.section.sec_description;
            let categories = obj.section.category;
            this.categories.push(...categories.splice(0, 3));
        },
        showArticle(id) {
            let data = new FormData();
            data.append('artId', id);
            fetch('/Patterns/Articles', { method: 'post', body: data }).then(r => r.json()).then(o => this.article = o.article[0]);
        }
    }
});

fetch('/Patterns/PatternPageStructure').then(r => r.json()).then(app.setCategories);