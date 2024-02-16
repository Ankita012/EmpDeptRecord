import './App.css';
import {Home} from './Home';
import {Department} from './Department';
import {Employee} from './Employee';
import {Navigation} from './Navigation';
import { BrowserRouter, Route, Routes} from 'react-router-dom';

function App() {
  return (
    <BrowserRouter>
      <div className="container">
        <h3 className="m-3 d-lex justiy-content-center">
          React Js tutorial
        </h3>
        <Navigation />
        <Routes>
          <Route path="/" element={<Home />}></Route>
          <Route path="/department" element={<Department />}></Route>
          <Route path="/employee" element={<Employee />}></Route>
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
