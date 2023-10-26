import React, { Component } from 'react';
import axios from 'axios';
import BlogCard from './BlogCard';

class BlogList extends Component {
  state = {
    blogs: [],
  };

  async componentDidMount() {
    try {
      const response = await axios.get('http://localhost:5269/api/blogs');
      this.setState({ blogs: response.data });
    } catch (error) {
      console.error('Error fetching blogs:', error);
    }
  }

  render() {
    const { blogs } = this.state;
    return (
      <div className="blog-list">
        <h2>Blogs</h2>
        {blogs.map((blog) => (
          <BlogCard key={blog.id} blog={blog} />
        ))}
      </div>
    );
  }
}

export default BlogList;
