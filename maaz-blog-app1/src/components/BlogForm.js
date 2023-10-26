import React, { Component } from 'react';

class BlogForm extends Component {
  state = {
    title: '',
    content: '',
  };

  handleInputChange = (e) => {
    const { name, value } = e.target;
    this.setState({ [name]: value });
  };

  handleSubmit = async (e) => {
    e.preventDefault();
    const { title, content } = this.state;
    // Make a POST request to create a new blog
    // You can implement this using the fetch API or a library like Axios.
    // Example: fetch('http://localhost:45447/api/blogs', {
    //   method: 'POST',
    //   body: JSON.stringify({ title, content }),
    //   headers: {
    //     'Content-Type': 'application/json',
    //   },
    // });
  };

  render() {
    return (
      <div>
        <h2>Create a New Blog</h2>
        <form onSubmit={this.handleSubmit}>
          <div>
            <label htmlFor="title">Title</label>
            <input
              type="text"
              id="title"
              name="title"
              value={this.state.title}
              onChange={this.handleInputChange}
            />
          </div>
          <div>
            <label htmlFor="content">Content</label>
            <textarea
              id="content"
              name="content"
              value={this.state.content}
              onChange={this.handleInputChange}
            />
          </div>
          <button type="submit">Create Blog</button>
        </form>
      </div>
    );
  }
}

export default BlogForm;
