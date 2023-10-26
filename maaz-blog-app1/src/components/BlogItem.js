import React from 'react';

const BlogItem = ({ blog }) => {
  return (
    <div className="blog-item">
      <h3>{blog.title}</h3>
      <p>{blog.content}</p>
      {/* Add buttons or functionality for editing and deleting the blog */}
    </div>
  );
};

export default BlogItem;
