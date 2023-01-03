import axios from "axios";

export default function GetApi(url) {
    let datas = axios.get(url).then(res => res.data);
    return datas;
}
