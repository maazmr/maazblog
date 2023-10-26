import React, { Component } from 'react';
import './App.css';
import BlogList from './components/BlogList';
import BlogForm from './components/BlogForm';

class App extends Component {
  render() {
    return (
      <div className="App">
        <h1>Maaz Blog App</h1>
        <BlogForm />
        <BlogList />
      </div>
    );
  }
}

export default App;
